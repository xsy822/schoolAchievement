<template>
	<div class="main">
		<p>邀请码</p>
		<p class="code">{{ code }}</p>
	</div>
</template>

<script>
	import axios from 'axios';
	import {
		useCookies
	} from "vue3-cookies";
	export default {
		name: 'Code',
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
				code: 666666
			}
		},
		created() {
			//获取数据
			axios.post('https://cloud.xiaoshiyan.top:8081/invition',{'token':this.cookies.get('token')}).then(res => {
				if (res.data.code == 0) {
					this.code=res.data.invitionCode
				}
				if(res.data.code==1){
					layer.msg(res.data.reason)
					this.$router.push('/')
				}
			}, e => {
				layer.msg(e)
			})
		}
	}
</script>

<style scoped>
	.main {
		width: 400px;
		height: 200px;
		border-radius: 15px;
		padding-top: 20px;
		color: white;
		margin: auto;
		margin-top: 200px;
		background-color: #00aaff;
	}

	@media screen and (max-width: 445px) {
		.main {
			width: 90%;
		}
	}

	.code {
		margin-top: 40px;
		font-size: 50px;
		font-weight: 100;
		letter-spacing: 10px;
	}
</style>
