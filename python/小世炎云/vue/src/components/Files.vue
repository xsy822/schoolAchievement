<template>
	<div class="layui-box">
		<button class="layui-btn layui-btn-sm" @click="multiDownload()">下载选中</button>
		<button class="layui-btn layui-btn-sm layui-bg-red" @click="multiDel()">删除选中</button>
		<table id="demo" lay-filter="test"></table>
		<div id="layer" style="display: none;">
			<p>(只有可预览文件才能预览)</p>
			<a :href="this.select.url" target="_blank"><button type="button"
					class="layui-btn layui-btn-sm layui-bg-blue" @click="a()">预览</button></a>
			<a :href="this.select.url1" target="_blank"><button type="button"
					class="layui-btn layui-btn-sm layui-bg-blue" @click="a()">下载</button></a>
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
		name: 'Files',
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

				},
			}
		},
		methods: {
			multiDownload(){
				let that=this;
				layui.use('table', function() {
					var table = layui.table;
				var checkStatus = table.checkStatus('demo');
				for (let obj of checkStatus.data) {
					that.change(obj);
					window.open(that.select.url1);
				}
				});
			},
			multiDel(){
				let that=this;
				layui.use('table', function() {
					var table = layui.table;
				var checkStatus = table.checkStatus('demo');
				for (let obj of checkStatus.data) {
					that.change(obj);
					that.del();
				}
				});
			},
			change(obj) {
				var url = obj.url;
				this.select = obj;
				this.select.filename2 = this.select.filename1
				this.select.filename1 = encodeURIComponent(this.select.filename1)
				url = encodeURIComponent(url)
				this.select.url = 'https://cloud.xiaoshiyan.top:8081/view?filename=' + this.select.filename1 + '&url=' +
					url + '&token=' + this.cookies.get('token');
				this.select.url1 = 'https://cloud.xiaoshiyan.top:8081/download?filename=' + this.select.filename1 +
					'&url=' + url + '&token=' + this.cookies.get('token');
			},
			del() {
				//请求删除，重新获取数据刷新
				axios.post('https://cloud.xiaoshiyan.top:8081/delfiles', {
					'filename': this.select.filename2,
					'token': this.cookies.get('token')
				}).then(res => {
					layer.close(layer.index);
					if (res.data.code != 0) {
						layer.msg('删除失败\n' + res.data.reason)
					} else {
						layer.msg('已删除文件' + this.select.filename);
						layui.use('table', function() {
							layui.table.reload('demo');
						})
					}
				});
			},
			a() {
				layer.close(layer.index);
			}
		},
		mounted() {
			let that = this
			//表格
			layui.use('table', function() {
				var table = layui.table;
				table.render({
					elem: '#demo',
					url: 'https://cloud.xiaoshiyan.top:8081/myfiles',
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
								type: 'checkbox',
								fiexd: 'left'
							},
							{
								field: 'filename',
								title: '文件名',
								edit: 'text',
								sort: true
							}, {
								field: 'class',
								title: '类型',
								event: 'singleclick',
								sort: true
							}, {
								field: 'size',
								title: '大小',
								event: 'singleclick',
								sort: true
							},
							{
								field: 'date',
								title: '时间',
								event: 'singleclick',
								sort: true
							}
						]
					],
				});
				//表格每行点击事件
				table.on('tool(test)', function(obj) {
					if (obj.event == 'singleclick') {
						console.log(11111);
						that.change(obj.data)
						//弹出框
						layer.open({
							type: 1,
							title: that.select.filename,
							area: ['300px', '200px'],
							shadeClose: true,
							content: $('#layer'),
							end: () => {
								$('#layer').hide();
							}
						});
					}
				});
				//编辑
				table.on('edit(test)', function(obj) {
					axios.post('https://cloud.xiaoshiyan.top:8081/changefile', {
						'filename': obj.data.filename1,
						'newname': obj.value,
						'token': that.cookies.get('token')
					}).then(res => {
						layer.close(layer.index);
						if (res.data.code != 0) {
							layer.msg('失败\n' + res.data.reason)
						} else {
							layer.msg('已重命名文件');
							layui.use('table', function() {
								layui.table.reload('demo');
							})
						}
					});
				});
			});
		}
	}
</script>

<style scoped>
	.layui-box {
		padding: 30px 50px;
		text-align: left;
	}

	#layer>p {
		margin: 10px 0;
		font-size: 5px;
		color: #969696;
	}

	#layer {
		padding: 20px;
		text-align: center;
	}

	a {
		margin-right: 10px;
	}
</style>
