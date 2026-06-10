import api from './api'

export const authService = {
    async login(username, password) {
        try {
            const response = await api.post('/Usuario/login', {
                nombreUsuario: username,
                clave: password
            });
            return response.data;
        } catch (error) {
            if (error.response && error.response.data) {
                return error.response.data;
            }
            return { ok: false, mensaje: 'Error de conexión con el servidor.' };
        }
    },
    
    async registrar(username, password) {
        try {
            const response = await api.post('/Usuario/registrar', {
                nombreUsuario: username,
                clave: password
            });
            return response.data;
        } catch (error) {
            if (error.response && error.response.data) {
                return error.response.data;
            }
            return { ok: false, mensaje: 'Error de conexión con el servidor.' };
        }
    }
}