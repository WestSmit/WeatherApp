import { createRouter, createWebHistory } from 'vue-router'
import SearchPage from '@/components/SearchPage.vue'
import HistoryPage from '@/components/HistoryPage.vue'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'search',
      component: SearchPage,
    },
    {
      path: '/history',
      name: 'history',
      component: HistoryPage,
    },
  ],
})

export default router
