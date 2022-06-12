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
			<div class="jizhu">
				<input lay-ignore type="checkbox" id="cbox1" @click="this.jizhuwo()">
				  <label for="cbox1">记住我</label>
			</div>
				
			<div class="layui-form-item">
				<div class="layui-input-block">
					<button type="button" class="layui-btn" lay-submit lay-filter="formDemo"
						@click="submit()">登录</button>
					<button type="reset" class="layui-btn layui-btn-primary layui-border-green">重置</button>
					<button type="button" class="layui-btn layui-btn-primary layui-btn-xs" @click="signup()">注册</button>
					<button type="button" class="layui-btn layui-btn-primary layui-btn-xs"
						@click="forget()">忘记密码?</button>
				</div>
			</div>
		</form>
		<div class="footer">
			<a href="https://beian.miit.gov.cn/">渝ICP备 2020014856号-1</a>
		</div>
	</div>
</template>

<script>
	import $ from 'jquery';
	import axios from 'axios';
	import {
		useCookies
	} from "vue3-cookies";
	export default {
		name: 'Login',
		setup() {
			const {
				cookies
			} = useCookies();
			return {
				cookies
			};
		},
		data() {
			return {
				user: {
					username: '',
					password: '',
					jizhu:null
				},
			}
		},
		methods: {
			submit() {
				//验证
				if (this.user.username.length == 0 || this.user.password.length == 0) {
					return
				}
				//提交信息
				axios.post('https://cloud.xiaoshiyan.top:8081/login', this.user).then(res => {
					if (res.data.code == 0) {
						//保存token
						this.cookies.set('token', res.data.token,"30d");
						this.$router.push('/User');
					} else {
						layer.msg("登录失败\n" + res.data.reason)
						this.user = {
							username: '',
							password: ''
						}
					}
				}, e => {
					layer.msg(e);
				})
			},
			forget() {
				this.$router.push('/Forget');
			},
			signup() {
				this.$router.push('/SignUp');
			},
			jizhuwo(){
				this.user.jizhu=this.user.jizhu^true;
				if(this.user.jizhu){
					layer.msg('勾选后登录信息保存30天');
				}
			}
		},
		created() {

			if (this.cookies.isKey('token')) {
				//存在token,验证
				axios.post('https://cloud.xiaoshiyan.top:8081/validate', {
					'token': this.cookies.get('token')
				}).then(res => {
					if (res.data.code == 0) {
						this.$router.push('/User');
					}
				}, e => {
					layer.msg(e)
				})
			}
			if (this.cookies.isKey('jizhu')){
				this.user.jizhu=this.cookies.get('jizhu');
			}
			else{
				this.user.jizhu=false;
			}
		},
		mounted() {
			let that = this;
			$(".layui-input").on("keypress", function(e) {
				var keycode = e.keyCode;
				if (keycode == "13") {
					that.submit();
				}
			});
			layui.use('form', function(){
			  var form = layui.form;
				form.render();
			});
		}
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
	.footer{
		margin-top: 30vh;
		text-align: center;
	}
	.jizhu{
		
		text-align: right;
	}
	.jizhu>*{
		display: inline-block;
		height: auto;
		line-height: normal;
		padding-left: 10px;
		cursor: pointer;
		vertical-align:middle;
		-webkit-user-select:none;
		-moz-user-select:none;
		-ms-user-select:none;
		user-select:none;
	}
</style>
