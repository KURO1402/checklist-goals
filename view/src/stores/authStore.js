import {defineStore} from 'pinia';
import { ref } from 'vue'
import { authService } from '../services/authService';

export const useAuthStore = defineStore('auth', () => {
  const token = ref(sessionStorage.getItem('token') || null);
  const usuario = ref(sessionStorage.getItem('usuario') || null);

  async function loginUsuario(nombre, clave) {
    const response = await authService.login(nombre, clave);

    if (response.ok) {
      token.value = response.token;
      usuario.value = response.nombreUsuario;

      sessionStorage.setItem('token', response.token);
      sessionStorage.setItem('usuario', response.nombreUsuario);
    }

    return response;
  }

  async function registerUsusario(nombre, clave) {
    const response = await authService.registrar(nombre, clave);

    if (response.ok) {
      token.value = response.token;
      usuario.value = response.nombreUsuario;

      sessionStorage.setItem('token', response.token);
      sessionStorage.setItem('usuario', response.nombreUsuario);
    }

    return response;
  }

  function logout() {
  token.value = null
  usuario.value = null

  sessionStorage.removeItem('token')
  sessionStorage.removeItem('usuario')
}

  return { token, usuario, loginUsuario, registerUsusario, logout };
});