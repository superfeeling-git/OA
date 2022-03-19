<template>
    <div>
        <el-card class="box-card">
            <div slot="header" class="clearfix">
                <span>卡片名称</span>
                <el-button style="float: right; padding: 3px 0" type="text">操作按钮</el-button>
            </div>
            <el-form ref="formField" :model="formField" label-width="80px">
                <el-form-item label="账号">
                    <el-input v-model="formField.account"></el-input>
                </el-form-item>
                <el-form-item label="密码">
                    <el-input v-model="formField.password"></el-input>
                </el-form-item>
                <el-form-item>
                    <el-button type="primary" @click="onSubmit">立即创建</el-button>
                    <el-button>取消</el-button>
                  </el-form-item>
            </el-form>
        </el-card>
    </div>
</template>

<script>
    import axios from '../axios'
    export default {
        data() {
            return {
                formField:{
                    account:"",
                    password:""
                }
            };
        },
        methods: {
            onSubmit(){
                axios.post('api/UserAccount/Login',this.formField).then((result) => {
                    //if()..提示错误信息
                    let token = result.data.token;
                    //保存
                    localStorage.setItem('token',token);
                }).catch((err) => {
                    
                });
            }
        },
    }
</script>

<style>
  .text {
    font-size: 14px;
  }

  .item {
    margin-bottom: 18px;
  }

  .clearfix:before,
  .clearfix:after {
    display: table;
    content: "";
  }
  .clearfix:after {
    clear: both
  }

  .box-card {
    width: 480px;
  }
</style>