import { createRouter, createWebHashHistory } from 'vue-router'


import Admin from '../pages/admin/Admin.vue'
const routes = [
  {
    path: '/',
    name: 'Admin',
    component: Admin,
    children :[
      {
        path:'',
        name: 'Pagination',
        component: () => import('@/pages/admin/Pagination.vue')
      },
      {
        path:'/products/create',
        name: 'ProductCreate',
        component: () => import('@/pages/admin/ProductCreate.vue')
      },
      {
        path:'/products/:id',
        name: 'ProductEdit',
        component: () => import('@/pages/admin/ProductEdit.vue'),
      },
      
    ]
  },
  
]

const router = createRouter({
  history: createWebHashHistory(),
  routes
})

export default router
