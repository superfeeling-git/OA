import Vue from 'vue'
import Router from 'vue-router'
import index from '../page/index'
import list from '../page/department/list'
import add from '../page/department/add'
import test from '../page/test'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'index',
      component: index,
      children: [
        {
          path: 'department/add',
          name: 'add',
          component: add,
        },
        {
          path: 'department/list',
          name: 'list',
          component: list,
        }
      ]
    },
    {
      path: '/test',
      name: 'test',
      component: test,
    },
    {
      path: '/coma',
      name: 'coma',
      component: ()=>import('@/page/coma'),
    },
    {
      path:"/login",
      name:"login",
      component:()=>import('@/page/login')
    }
  ]
})
