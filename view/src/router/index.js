import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name: 'Inicio',
            component: () => import('../views/public/LandingView.vue')
        },
        {
            path: '/login',
            name: 'Inicio de sesion',
            component: () => import('../views/public/LoginPage.vue')
        },
        {
            path: '/register',
            name: 'Registro de usuario',
            component: () => import('../views/public/RegisterPage.vue')
        },
        {
            path: '/dashboard',
            name: 'Dashboard',
            component: () => import('../views/private/Dashboard.vue'),
            meta: {requiresAuth: true}
        }
    ]
});

function isAuthenticated() {
  return !!sessionStorage.getItem('token') 
}

router.beforeEach((to, from, next) => {
  if (to.meta.requiresAuth) {
    
    if (isAuthenticated()) {
      next() 
    } else {
      next({ name: 'Inicio de sesion' }) 
    }

  } else {
    next() 
  }
})

export default router