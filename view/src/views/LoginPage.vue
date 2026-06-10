<script setup>
import { ref, reactive } from 'vue'
import { User, Lock, Eye, EyeOff } from 'lucide-vue-next'
import { RouterLink } from 'vue-router'
import { useAuthStore } from '../stores/authStore'

const authStore = useAuthStore();
const showPassword = ref(false)
const loginMessage = ref(false)
const okResponse = ref(false);
const cargando = ref(false);
const form = reactive({
  nombre: '',
  clave: ''
})
let message = ref("")

const inputClass = (hasError) => [
  'w-full pl-9 pr-10 py-2.5 rounded-xl border bg-background text-text text-sm',
  'placeholder:text-text-muted/50 focus:outline-none focus:ring-2 transition-all',
  hasError
    ? 'border-red-500 ring-2 ring-red-500/15'
    : 'border-border focus:border-primary focus:ring-primary/15'
]
const enviarDatos = async () => {
  loginMessage.value = false
  message.value = ""

  if (!form.nombre && !form.clave) {
    loginMessage.value = true
    message.value = "Falta ingresar el nombre y la contraseña."
    return
  }

  if (!form.nombre) {
    loginMessage.value = true
    message.value = "Falta ingresar el nombre."
    return
  }

  if (!form.clave) {
    loginMessage.value = true
    message.value = "Falta ingresar la contraseña."
    return
  }

  cargando.value = true

  try {
    const response = await authStore.loginUsuario(form.nombre, form.clave)

    if (response.ok) {
      okResponse.value = false
      alert(response.mensaje)
      console.log('Login correcto: ', response)
    } else {
      okResponse.value = true
      loginMessage.value = true
      message.value = response.mensaje
    }
  } catch (error) {
    loginMessage.value = true
    message.value = error.response?.data?.mensaje || 'Error de conexión con el servidor.'
    console.error('Error en la petición:', error)
  } finally {
    cargando.value = false
  }
}
</script>
<template>
  <div class="flex justify-center items-start md:mt-7 min-h-screen bg-background px-5 py-12">
    <div
      class="flex flex-col w-full max-w-sm bg-surface border border-border rounded-2xl p-6 md:p-8 shadow-md shadow-text/5 [html.dark_&]:shadow-black/40">

      <!-- Logo -->
      <div class="flex justify-center mb-6">
        <div class="flex items-center gap-2">
          <div aria-hidden="true" class="w-[32px] h-[32px] bg-primary rounded-[6px] flex items-center justify-center">
            <div class="w-[11px] h-[11px] rounded-full bg-background"></div>
          </div>
          <span class="font-bold text-xl text-text">AimHigh</span>
        </div>
      </div>

      <!-- Título -->
      <div class="mb-6 text-center">
        <h1 class="text-2xl font-semibold text-text">Bienvenido de nuevo</h1>
        <p class="text-sm text-text-muted mt-1">Ingresa tus datos para continuar</p>
      </div>

      <!-- Formulario -->
      <form class="flex flex-col gap-4" @submit.prevent="enviarDatos">

        <!-- Usuario -->
        <div class="flex flex-col gap-1.5">
          <label class="text-sm font-medium text-text-muted">Nombre de form</label>
          <div class="relative">
            <User class="absolute left-3 top-1/2 -translate-y-1/2 text-text-muted" :size="16" />
            <input v-model="form.nombre" type="text" placeholder="tu_usuario"
              :class="inputClass(loginMessage && !form.nombre || okResponse)" />
          </div>
        </div>

        <!-- Contraseña -->
        <div class="flex flex-col gap-1.5">
          <label class="text-sm font-medium text-text-muted">Contraseña</label>
          <div class="relative">
            <Lock class="absolute left-3 top-1/2 -translate-y-1/2 text-text-muted" :size="16" />
            <input v-model="form.clave" placeholder="123456" :type="showPassword ? 'text' : 'password'"
              :class="inputClass(loginMessage && !form.clave || okResponse)" />
            <button type="button" @click="showPassword = !showPassword"
              class="absolute right-3 top-1/2 -translate-y-1/2 text-text-muted hover:text-primary transition-colors">
              <Eye v-if="!showPassword" :size="16" />
              <EyeOff v-else :size="16" />
            </button>
          </div>
          <a class="text-xs text-primary hover:opacity-75 transition-opacity cursor-pointer self-end">
            ¿Olvidaste tu contraseña?
          </a>
        </div>

        <!-- Submit -->
        <button type="submit" :disabled="cargando" class="w-full py-2.5 mt-1 bg-primary text-[#0a1a0d] font-semibold text-sm rounded-xl hover:bg-primary/90 active:scale-95 transition-all duration-200 
         disabled:opacity-50 disabled:cursor-not-allowed disabled:pointer-events-none">
          {{ cargando ? 'Iniciando sesión...' : 'Iniciar sesión' }}
        </button>
      </form>
      <div v-if="loginMessage" class="text-red-500 mt-5 text-sm text-center font-medium">
        <p>{{ message }}</p>
      </div>

      <!-- Footer -->
      <p class="text-sm text-text-muted text-center mt-5">
        ¿No tienes cuenta?
        <RouterLink to="/register" class="text-primary font-medium hover:opacity-75 transition-opacity">
          Regístrate
        </RouterLink>
      </p>

    </div>
  </div>
</template>