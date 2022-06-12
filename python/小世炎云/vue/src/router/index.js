import {
	createRouter,
	createWebHistory
} from 'vue-router'


const routes = [{
		path: '/',
		name: 'Login',
		component: () => import('../views/Login.vue')
	},
	{
		path: '/Login',
		redirect: '/'
	},
	{
		path: '/Forget',
		name: 'Forget',
		component: () => import('../views/Forget.vue')
	},
	{
		path: '/SignUp',
		name: 'SignUp',
		component: () => import('../views/SignUp.vue')
	},
	{
		path: '/Master',
		name: 'Master',
		component: () => import('../views/Master.vue')
	},
	{
		path: '/User',
		name: 'User',
		component: () => import('../views/User.vue')
	}
]

const router = createRouter({
	history: createWebHistory(process.env.BASE_URL),
	routes
})

export default router
