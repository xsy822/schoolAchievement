<template>
	<div class="layui-box">
		<ul class="layui-nav layui-bg-blue" lay-filter="">
			<li class="layui-nav-item">
				<a href="javascript:;"><i class="layui-icon layui-icon-username"></i> {{ this.nameLimitLen }}</a>
				<dl class="layui-nav-child">
					<dd @click="change()"><a href="javascript:;">修改信息</a></dd>
					<dd @click="toUser()"><a href="javascript:;">用户界面</a></dd>
					<dd @click="quit()"><a href="javascript:;">退出</a></dd>
				</dl>
			</li>
			<li class="layui-nav-item layui-this" @click="this.current=links.code"><a href="javascript:;"><i
						class="layui-icon layui-icon-vercode"></i> 邀请码</a></li>
			<li class="layui-nav-item" @click="this.current=links.manage"><a href="javascript:;"><i
						class="layui-icon layui-icon-user"></i> 用户管理</a></li>
		</ul>
		<div class="layui-box">
			<component :is="this.current"></component>
		</div>
		<div id="change" style="display: none;">
			<form class="layui-form layui-form-pane">
				<div class="layui-form-item">
					<label class="layui-form-label">密码</label>
					<div class="layui-input-block">
						<input type="password" name="username" required lay-verify="required" autocomplete="off"
							class="layui-input" v-model="password1">
					</div>
				</div>
				<div class="layui-form-item">
					<label class="layui-form-label">确认密码</label>
					<div class="layui-input-block">
						<input type="password" name="password" required lay-verify="required" autocomplete="off"
							class="layui-input" v-model="password2">
					</div>
				</div>
				<div class="layui-form-item">
					<div class="layui-input-block">
						<button type="button" class="layui-btn" lay-submit lay-filter="formDemo"
							@click="submit()">确认修改</button>
						<button type="reset" class="layui-btn layui-btn-primary layui-border-green">重置</button>
					</div>
				</div>
			</form>
		</div>
	</div>
</template>
<script>
	import $ from 'jquery';
	import axios from 'axios';
	import {
		useCookies
	} from "vue3-cookies";
	import Code from '../components/Code.vue';
	import Manage from '../components/Manage.vue';
	export default {
		name: 'Master',
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
				current: Code,
				username: '我',
				links: {
					manage: Manage,
					code: Code
				}
			}
		},
		computed: {
			nameLimitLen() {
				return this.username.length > 10 ? this.username.slice(0, 10) + '' : this.username;
			}
		},
		methods: {
			change() {
				layer.open({
					type: 1,
					title: '修改密码',
					area: ['500px', '270px'],
					resize: false,
					shadeClose: true,
					content: $('#change'),
					end: () => {
						$('#change').hide();
					}
				});
			},
			toUser() {
				this.$router.push('/User')
			},
			submit(){
				if(this.password1!='' & this.password2!=''){
				if(this.password1!=this.password2){
					layer.msg('两次密码输入不相同')
				}
				else{
					axios.post('https://cloud.xiaoshiyan.top:8081/changepwd', {'token':this.cookies.get('token'),'password':this.password1}).then(res => {
						if (res.data.code == 0) {
							layer.close(layer.index)
							this.password1=null
							this.password2=null
							layer.msg('修改成功')
						} else {
							layer.msg("失败\n"+res.data.reason);
							this.password1='';
							this.password2='';
						}
					}, e => {
						layer.msg(e)
					})
				}
				}
			},
			quit() {
				//删除cookie,跳转到登录
				this.cookies.remove('token')
				this.$router.push('/')
			}
		},
		comments: {
			Code,
			Manage
		},
		created() {
			axios.post('https://cloud.xiaoshiyan.top:8081/validate',{'token':this.cookies.get('token')}).then(res => {
				if (res.data.code == 0) {
					if (res.data.level != 2) {
						alert('权限不足')
						this.$router.push('/User')
					} else {
						this.username = res.data.username
					}
				}
			}, e => {
				layer.msg(e);
				this.$router.push('/');
			})
		},
		mounted() {
			const _this = this;
			layui.use(['element'], function() {
				_this.element = layui.element;
				this.element.render();
			})
		}
	}
</script>

<style scoped>
	ul {
		text-align: left;
	}

	#change {
		padding: 30px;
	}
</style>
