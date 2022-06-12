<template>
	<div class="main">
		<div class="layui-panel" id="up">
			<div style="padding: 30px;"><i class="layui-icon layui-icon-upload"></i>上传文件<br>可拖放文件上传
			</div>
		</div>
	</div>
</template>

<script>
	import {
		useCookies
	} from "vue3-cookies";
	import axios from 'axios';
	export default {
		name: 'Upload',
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
				rest: null
			}
		},
		created() {
			axios.post('https://cloud.xiaoshiyan.top:8081/count', {
				'token': this.cookies.get('token')
			}).then(res => {
				if (res.data.code != 0) {
					layer.msg('登录信息失效');
					this.$router.push('/');
				} else {
					this.rest = res.data.count.rest
				}
			}, e => {
				layer.msg(e);
				this.$router.push('/');
			})
		},
		methods:{
			upReload(){
				this.uploadInst.reload(this.uploadInfo);
			}
		},
		mounted() {
			let that = this;
			//文件上传
			var upload = layui.upload;
			layui.use('upload', function() {
				that.uploadInfo={
					elem: '#up',
					url: 'https://cloud.xiaoshiyan.top:8081/upload',
					accept: 'file',
					auto: false,
					multiple:true,
					choose: function(obj) {
						var a = this;
						obj.preview(function(index, file, result) {
							//获取大小,上传参数
							a.data = {
								'length': file.size,
								'token': that.cookies.get('token')
							}
							if (file.size > that.rest) {
								console.log(file.size,that.rest)
								layer.msg("剩余空间不足，上传失败！");
								that.upReload();
							} else {
								obj.upload(index, file);
								layer.load();
							}
						})
					},
					done: function(res) {
						if (res.code != 0) {
							layer.msg("上传失败\n" + res.reason)
						} else {
							layer.msg('上传成功');
						}
						layer.closeAll('loading');
					},
					error: function(index, upload) {
						layer.closeAll('loading');
						layer.msg('接口出现异常');
						that.upReload();
					}
				}
				that.uploadInst = upload.render(that.uploadInfo);
			});
		}
	}
</script>

<style scoped>
	.main {
		padding: 20px 0px;
		margin: auto;
		margin-top: 20vh;
		line-height: 3;
		user-select: none;
		width: 600px;
	}

	#up {
		cursor: pointer;
	}

	@media screen and (max-width: 620px) {
		.main {
			width: 90%;
		}
	}

	.layui-panel {
		border: 2px dashed #63c1ff;
		color: #63c1ff;
		transition: 0.5s;
	}

	.layui-panel:hover {
		border: 2px dashed #3496ff;
		color: #3496ff;
	}
</style>
