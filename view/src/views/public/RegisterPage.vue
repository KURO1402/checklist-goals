<script setup>
import { ref, reactive } from 'vue'
import { User, Lock, Eye, EyeOff } from 'lucide-vue-next'
import { RouterLink } from 'vue-router'
import { useAuthStore } from '../../stores/authStore'

// 1. Agrupamos inicializaciones arriba
const authStore = useAuthStore()

const showPassword = ref(false)
const showPasswordConfirm = ref(false)
const registerMessage = ref(false)
const okResponse = ref(false)
const cargando = ref(false)
const message = ref('')

const form = reactive({
    nombre: '',
    clave: '',
    claveConfirm: ''
})

const inputClass = (hasError) => [
    'w-full pl-9 pr-10 py-2.5 rounded-xl border bg-background text-text text-sm',
    'placeholder:text-text-muted/50 focus:outline-none focus:ring-2 transition-all',
    hasError
        ? 'border-red-500 ring-2 ring-red-500/15'
        : 'border-border focus:border-primary focus:ring-primary/15'
]

const enviarDatos = async () => {
    registerMessage.value = false
    message.value = ''

    if (!form.nombre && !form.clave) {
        registerMessage.value = true
        message.value = 'Falta ingresar el usuario y la contraseña.'
        return
    }

    if (!form.nombre) {
        registerMessage.value = true
        message.value = 'Falta ingresar el usuario.'
        return
    }

    if (!form.clave) {
        registerMessage.value = true
        message.value = 'Falta ingresar la contraseña.'
        return
    }

    if (form.clave !== form.claveConfirm) {
        registerMessage.value = true
        message.value = 'Las contraseñas no coinciden.'
        return
    }

    cargando.value = true

    try {
        const response = await authStore.registerUsusario(form.nombre, form.clave)

        if (response.ok) {
            okResponse.value = false
            alert(response.mensaje || '¡Registro exitoso!')
            console.log("Registro correcto:", response)
        } else {
            okResponse.value = true
            registerMessage.value = true
            message.value = response.mensaje
        }
    } catch (error) {
        okResponse.value = true
        registerMessage.value = true
        message.value = error.response?.data?.mensaje || 'Error al conectar con el servidor.'
        console.error("Error en registro:", error)
    } finally {
        cargando.value = false
    }
}
</script>
<template>
    <div class="flex justify-center items-start md:min-h-screen bg-background px-5 py-12">
        <div
            class="flex flex-col w-full max-w-sm bg-surface border border-border rounded-2xl p-6 md:p-8 shadow-md shadow-text/5 [html.dark_&]:shadow-black/40">
            <!-- Logo -->
            <div class="flex justify-center mb-6">
                <div class="flex items-center gap-2">
                    <div aria-hidden="true"
                        class="w-[32px] h-[32px] bg-primary rounded-[6px] flex items-center justify-center">
                        <div class="w-[11px] h-[11px] rounded-full bg-background"></div>
                    </div>
                    <span class="font-bold text-xl text-text">AimHigh</span>
                </div>
            </div>
            <!-- Título -->
            <div class="mb-6 text-center">
                <h1 class="text-2xl font-semibold text-text">Registro</h1>
                <p class="text-sm text-text-muted mt-1">Registra tus datos para empezar</p>
            </div>
            <form class="flex flex-col gap-4" @submit.prevent="enviarDatos">

                <!-- Usuario -->
                <div class="flex flex-col gap-1.5">
                    <label class="text-sm font-medium text-text-muted">Nombre de usuario</label>
                    <div class="relative">
                        <User class="absolute left-3 top-1/2 -translate-y-1/2 text-text-muted" :size="16" />
                        <input v-model="form.nombre" type="text" placeholder="tu_usuario"
                            :class="inputClass(registerMessage && !form.nombre || okResponse)" />

                    </div>
                </div>

                <!-- Contraseña -->
                <div class="flex flex-col gap-1.5">
                    <label class="text-sm font-medium text-text-muted">Contraseña</label>
                    <div class="relative">
                        <Lock class="absolute left-3 top-1/2 -translate-y-1/2 text-text-muted" :size="16" />
                        <input v-model="form.clave" :type="showPassword ? 'text' : 'password'" placeholder="123456"
                            :class="inputClass(registerMessage && (!form.clave || form.clave !== form.claveConfirm))" />
                        <button type="button" @click="showPassword = !showPassword"
                            class="absolute right-3 top-1/2 -translate-y-1/2 text-text-muted hover:text-primary transition-colors">
                            <Eye v-if="!showPassword" :size="16" />
                            <EyeOff v-else :size="16" />
                        </button>
                    </div>
                </div>
                <!-- Repetir contraseña -->
                <div class="flex flex-col gap-1.5">
                    <label class="text-sm font-medium text-text-muted">Repita su contraseña</label>
                    <div class="relative">
                        <Lock class="absolute left-3 top-1/2 -translate-y-1/2 text-text-muted" :size="16" />
                        <input v-model="form.claveConfirm" :type="showPasswordConfirm ? 'text' : 'password'"
                            placeholder="123456"
                            :class="inputClass(registerMessage && (!form.claveConfirm || form.clave !== form.claveConfirm))" />
                        <button type="button" @click="showPasswordConfirm = !showPasswordConfirm"
                            class="absolute right-3 top-1/2 -translate-y-1/2 text-text-muted hover:text-primary transition-colors">
                            <Eye v-if="!showPasswordConfirm" :size="16" />
                            <EyeOff v-else :size="16" />
                        </button>
                    </div>
                </div>

                <!-- Submit -->
                <button type="submit" :disabled="cargando"
                    class="w-full py-2.5 mt-1 bg-primary text-[#0a1a0d] font-semibold text-sm rounded-xl hover:bg-primary/90 active:scale-95 transition-all duration-200 disabled:opacity-50 disabled:cursor-not-allowed disabled:pointer-events-none disabled:cursor-not-allowed disabled:pointer-events-none">
                    {{ cargando ? 'Registrando cuenta...' : 'Registrarse' }}
                </button>
                <div v-if="registerMessage" class="text-red-500 mt-5 text-sm text-center font-medium">
                    <p>{{ message }}</p>
                </div>

            </form>
            <!-- Footer -->
            <p class="text-sm text-text-muted text-center mt-5">
                ¿Ya tienes una cuenta?
                <RouterLink to="/login" class="text-primary font-medium hover:opacity-75 transition-opacity">
                    Inicia sesion
                </RouterLink>
            </p>
        </div>
    </div>
</template>