import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'Inicio',
            component: () => import('../views/LandingView.vue')
        },
        {
            path: '/login',
            name: 'Inicio de sesion',
            component: () => import('../views/LoginPage.vue')
        }
    ]
})

export default router