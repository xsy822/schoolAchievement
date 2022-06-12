<template>
	<div class="main">
		<div class="layui-progress layui-progress-big" lay-filter="demo" lay-showPercent="yes">
			<div :class="['layui-progress-bar', this.color]" :lay-percent="this.percent"></div>
		</div>
		<fieldset class="layui-elem-field layui-field-title">
			<legend class="layui-border-blue">空间使用情况</legend>
		</fieldset>
		<div class="layui-field-box">
			<div class="layui-card">
				<div class="layui-card-header">使用量/剩余量</div>
				<div class="layui-card-body">
					<i class="count">{{ this.used }}</i>KB　(约{{this.used1}}MB)　<i class="big">/</i><i class="count"> {{ this.rest }}</i>KB
					(约{{this.rest1}}MB)
				</div>
			</div>
		</div>
		<hr class="layui-border-blue">
		<div class="layui-field-box">
			<div class="layui-card">
				<div class="layui-card-header">文件数量</div>
				<div class="layui-card-body">
					<i class="count">{{ this.amount }}</i>　个
				</div>
			</div>
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
		name: 'Count',
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
				used:null,
				used1:null,
				rest:null,
				rest1:null,
				amount:null,
				p: 99
			}
		},
		computed: {
			color() {
				let colors = ["layui-bg-blue", "layui-bg-orange", "layui-bg-red"]
				return colors[(this.p - (this.p % 33.3)) / 33.3]
			},
			percent() {
				return this.p.toFixed(2).toString() + '%';
			}
		},
		created() {
			axios.post('https://cloud.xiaoshiyan.top:8081/count',{'token':this.cookies.get('token')}).then(res => {
				if (res.data.code != 0) {
					layer.msg('登录信息失效');
					this.$router.push('/');
				} else {
					this.used=parseFloat((res.data.count.used/1024).toFixed(3))
					this.rest=parseFloat((res.data.count.rest/1024).toFixed(3))
					this.used1=(this.used/1024).toFixed(3)
					this.rest1=(this.rest/1024).toFixed(3)
					this.amount=res.data.count.amount
					var p=this.used/((this.rest+this.used)/100)
					this.p=p
					layui.use(['element'], function() {
						$('.layui-progress-bar').attr('lay-percent',p+'%');
						this.element.init();
						this.element.progress('demo', p+'%');
					})
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
	.main {
		padding: 20px 0px;
		margin: 0px 50px;
		text-align: left;
	}

	@media screen and (max-width: 500px) {
		.main {
			margin: 0 5%;
		}
	}
	.count{
		font-weight: 100;
		font-size: 30px;
	}
	.big{
		font-size: 50px;
	}
</style>
