<template>
	<div class="layui-box">
		<table id="demo" lay-filter="test"></table>
		<div id="layer" style="display: none;">
			<p class="del">删除用户 <i>{{select.username}}</i> ?</p>
			<button type="button" class="layui-btn layui-btn-sm layui-btn-danger" @click="del()">删除</button>
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
		name: 'Manage',
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
				select: {
					username: '111',
					password: '',
					level: 0
				}
			}
		},
		methods: {
			del() {
				if (this.select.level == 2) {
					layer.msg('不能删除其他管理员');
				} else {
					//请求删除，重新获取数据刷新
					axios.post('https://cloud.xiaoshiyan.top:8081/deluser', {
						'username': this.select.username,
						'token': this.cookies.get('token')
					}).then(res => {
						layer.msg('已删除用户' + this.select.username);
						layui.use('table', function() {
							layui.table.reload('demo');
						})
					});
				}
				layer.close(layer.index)
			},
			change(data) {
				this.select = data
			}
		},
		mounted() {
			let that = this
			//表格
			layui.use('table', function() {
				var table = layui.table;
				table.render({
					elem: '#demo',
					url: 'https://cloud.xiaoshiyan.top:8081/manage',
					page: true,
					where: {
						'token': that.cookies.get('token')
					},
					done: function(res) {
						if (res.code != 0) {
							layer.msg(res.reason);
							that.$router.push('/');
						}
					},
					cols: [
						[{
								field: 'username',
								title: '用户名',
								sort: true
							}, {
								field: 'password',
								title: '密码'
							}, {
								field: 'level',
								title: '权限'
							},
							{
								field: 'used',
								title: '使用量(B)',
								sort: true
							}, {
								field: 'rest',
								title: '剩余量(B)',
								sort: true
							}, {
								field: 'amount',
								title: '文件数量',
								sort: true
							}
						]
					],
				});
				//表格每行点击事件
				table.on('row(test)', function(obj) {
					that.change(obj.data)
					//弹出框
					layer.open({
						type: 1,
						title: '操作',
						area: ['300px', '170px'],
						content: $('#layer'),
						end: () => {
							$('#layer').hide();
						}
					});
				});
			});
		}
	}
</script>

<style scoped>
	.layui-box {
		padding: 30px 3%;
		text-align: left;
	}

	.del {
		margin: 20px 0px;
		margin-top: 30px;
	}

	.del>i {
		font-size: 25px;
		font-weight: 300;
		color: #ff8025;
	}

	#layer {
		text-align: center;
	}
</style>
