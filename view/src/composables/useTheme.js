import { ref, watchEffect } from 'vue'

const isDark = ref(localStorage.getItem('theme') === 'dark' ?? true)

watchEffect(() => {
  document.documentElement.classList.toggle('dark', isDark.value)
  localStorage.setItem('theme', isDark.value ? 'dark' : 'light')
})

export function useTheme() {
  const toggleTheme = () => (isDark.value = !isDark.value)
  return { isDark, toggleTheme }
}