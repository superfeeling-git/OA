import Vue from 'vue'
import Router from 'vue-router'
import index from '../page/index'
import create from '../page/department/create'
import list from '../page/department/list'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'index',
      component: index,
      children: [
        {
          path: 'department/create',
          name: 'create',
          component: create,
        },
        {
          path: 'department/list',
          name: 'list',
          component: list,
        }
      ]
    }
  ]
})
