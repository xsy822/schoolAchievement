<template>
	<div class="main">
		<form class="layui-form layui-form-pane">
			<div class="layui-form-item">
				<label class="layui-form-label">用户名</label>
				<div class="layui-input-block">
					<input type="text" name="username" required lay-verify="required" placeholder="请输入用户名"
						autocomplete="off" class="layui-input" maxlength="20" v-model="user.username">
				</div>
			</div>
			<div class="layui-form-item">
				<label class="layui-form-label">密码框</label>
				<div class="layui-input-block">
					<input type="password" name="password" required lay-verify="required" placeholder="请输入密码"
						autocomplete="off" class="layui-input" maxlength="20" v-model="user.password">
				</div>
			</div>
			<div class="layui-form-item">
				<label class="layui-form-label">邀请码</label>
				<div class="layui-input-inline">
					<input type="text" name="code" required lay-verify="required" placeholder="请输入邀请码"
						autocomplete="off" class="layui-input" maxlength="6" v-model="user.code">
				</div>
				<div class="layui-form-mid layui-word-aux">联系管理员获得</div>
			</div>
			<div class="layui-form-item">
				<div class="layui-input-block">
					<button type="button" class="layui-btn layui-btn-primary layui-border-blue"
						@click="back()">返回</button>
					<button type="button" class="layui-btn" lay-submit lay-filter="formDemo"
						@click="submit()">注册</button>
					<button type="reset" class="layui-btn layui-btn-primary layui-border-green">重置</button>
				</div>
			</div>
		</form>
	</div>
</template>

<script>
	import axios from 'axios'
	export default {
		name: 'SignUp',
		data() {
			return {
				user: {
					username: '',
					password: '',
					code: '',
				},
			}
		},
		methods: {
			submit() {
				//验证
				if(this.user.username.length==0 || this.user.password.length==0 || this.user.code.length==0){
					return
				}
				else if(this.user.code.length!=6){
					layer.msg('请输入六位邀请码!')
					return
				}
				//提交信息
				axios.post('https://cloud.xiaoshiyan.top:8081/signup', this.user).then(res => {
					if (res.data.code == 0) {
						layer.msg("注册成功，请重新登录")
						this.$router.push('/Login')
					} else {
						layer.msg("注册失败\n"+res.data.reason)
						this.user = {
							username: '',
							password: '',
							code: '',
						}
					}
				}, e => {
					layer.msg(e)
				})
			},
			back() {
				this.$router.push('/Login')
			}
		},
	}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
	.main {
		width: 600px;
		margin: auto;
		margin-top: 200px;
	}

	@media screen and (max-width: 500px) {
		.main {
			width: 90%;
		}
	}
</style>
