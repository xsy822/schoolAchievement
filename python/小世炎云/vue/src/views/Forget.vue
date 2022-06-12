<template>
	<button type="button" class="layui-btn layui-btn-primary layui-border-blue"
		@click="back()">返回</button>
	<div>
		请联系网站管理员
	</div>
</template>

<script>
	export default {
		name: 'Forget',
		methods:{
			back() {
				this.$router.push('/Login')
			}
		}
	}
</script>

<style>
</style>
