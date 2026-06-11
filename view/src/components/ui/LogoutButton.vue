<script setup>
import { useRouter } from 'vue-router'
import { LogOut } from 'lucide-vue-next'
import { useAuthStore } from '../../stores/authStore'

const authStore = useAuthStore()
const router = useRouter()

const gestionarLogout = () => {
  authStore.logout()
}
</script>

<template>
  <button 
    @click="gestionarLogout"
    class="flex items-center gap-2 px-4 py-2 text-sm font-medium text-primary rounded-xl cursor-pointer hover:primary/70"
  >
    <LogOut :size="25" />
  </button>
</template>