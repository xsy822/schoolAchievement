<template>
	<div class="layui-box">
		<ul class="layui-nav layui-bg-blue" lay-filter="">
			<li class="layui-nav-item">
				<a href="javascript:;"><i class="layui-icon layui-icon-username"></i> {{ this.nameLimitLen }}</a>
				<dl class="layui-nav-child">
					<dd @click="change()"><a href="javascript:;">修改信息</a></dd>
					<dd v-if="level==2" @click="toMaster()"><a href="javascript:;">管理</a></dd>
					<dd @click="quit()"><a href="javascript:;">退出</a></dd>
				</dl>
			</li>
			<li class="layui-nav-item layui-this" @click="current=links.file"><a href="javascript:;">
					<i class="layui-icon layui-icon-file"></i> 文件</a></li>
			<li class="layui-nav-item" @click="current=links.upload"><a href="javascript:;">
					<i class="layui-icon layui-icon-release"></i> 上传</a></li>
			<li class="layui-nav-item" @click="current=links.count"><a href="javascript:;">
					<i class="layui-icon layui-icon-senior"></i> 统计</a></li>
			<li class="layui-nav-item right"><a href="https://blog.xiaoshiyan.top/" target="_blank">
					<i class="layui-icon layui-icon-rate-solid"></i> 博客</a></li>
			<li class="layui-nav-item right"><a href="https://cloud.xiaoshiyan.top/files/XSYCloud.msi" target="_blank">
					<i class="layui-icon layui-icon-windows"></i> 安装</a></li>

		</ul>
		<div class="layui-box">
			<component :is="current"></component>
		</div>
		<div id="change" style="display: none;">
			<form class="layui-form layui-form-pane">
				<div class="layui-form-item">
					<label class="layui-form-label">密码</label>
					<div class="layui-input-block">
						<input type="password" name="password1" required lay-verify="required" autocomplete="off"
							class="layui-input" maxlength="20" v-model="password1">
					</div>
				</div>
				<div class="layui-form-item">
					<label class="layui-form-label">确认密码</label>
					<div class="layui-input-block">
						<input type="password" name="password2" required lay-verify="required" autocomplete="off"
							class="layui-input" maxlength="20" v-model="password2">
					</div>
				</div>
				<div class="layui-form-item">
					<div class="layui-input-block">
						<button type="button" class="layui-btn" lay-submit lay-filter="formDemo"
							@click="this.submit()">确认修改</button>
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
	import Files from '../components/Files.vue';
	import Count from '../components/Count.vue';
	import UpLoad from '../components/UpLoad.vue';
	import {
		useCookies
	} from "vue3-cookies";
	export default {
		setup() {
			const {
				cookies
			} = useCookies();
			return {
				cookies
			};
		},
		name: 'User',
		data() {
			return {
				current: Files,
				username: '我',
				level: null,
				links: {
					file: Files,
					count: Count,
					upload: UpLoad
				},
				password1: null,
				password2: null
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
			toMaster() {
				this.$router.push('/Master');
			},
			submit() {
				if (this.password1 != '' & this.password2 != '') {
					if (this.password1 != this.password2) {
						layer.msg('两次密码输入不相同')
					} else {
						axios.post('https://cloud.xiaoshiyan.top:8081/changepwd', {
							'token': this.cookies.get('token'),
							'password': this.password1
						}).then(res => {
							if (res.data.code == 0) {
								layer.close(layer.index)
								this.password1 = null
								this.password2 = null
								layer.msg('修改成功')
							} else {
								layer.msg("失败\n" + res.data.reason);
								this.password1 = '';
								this.password2 = '';
							}
						}, e => {
							layer.msg(e)
						})
					}
				}
			},
			quit() {
				//删除cookie,跳转到登录
				this.cookies.remove('token');
				this.$router.push('/');
			}
		},
		comments: {
			Files,
			Count,
			UpLoad
		},
		created() {
			axios.post('https://cloud.xiaoshiyan.top:8081/validate', {
				'token': this.cookies.get('token')
			}).then(res => {
				if (res.data.code != 0) {
					layer.msg('登录信息失效')
					this.$router.push('/')
				} else {
					this.username = res.data.username;
					this.level = res.data.level;
				}
			}, e => {
				layer.msg(e);
				this.$router.push('/');
			})
		},
		mounted() {
			const _this = this;
			layer.msg('本站不对上传文件及账号的安全做出保障!');
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

	.right {
		float: right;
	}
</style>
