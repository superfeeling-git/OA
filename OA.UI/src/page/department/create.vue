<template>
  <div>
    <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
      <el-form-item label="部门名称" prop="name">
        <el-input v-model="ruleForm.name"></el-input>
      </el-form-item>
      <el-form-item label="上级部门" prop="name">
        <el-cascader v-model="value" :options="options" @change="handleChange"></el-cascader>
      </el-form-item>
      <el-form-item label="部门负责人" prop="name">
        <el-input v-model="ruleForm.name"></el-input>
      </el-form-item>
      <el-form-item label="备注" prop="name">
        <el-input type="textarea" v-model="ruleForm.desc" :rows="8"></el-input>
      </el-form-item>

      <el-form-item>
        <el-button type="primary" @click="submitForm('ruleForm')">立即创建</el-button>
        <el-button @click="resetForm('ruleForm')">重置</el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script>
  import axios from '@/axios'
  export default {
    data() {
      return {
        ruleForm: {
          name: "",
          region: "",
          date1: "",
          date2: "",
          delivery: false,
          type: [],
          resource: "",
          desc: "",
        },
        rules: {
          name: [{ required: true, message: "请输入部门名称", trigger: "blur" }],
        },
        value: [],
        options: []
      };
    },
    methods: {
      submitForm(formName) {
        this.$refs[formName].validate((valid) => {
          if (valid) {
            alert("submit!");
          } else {
            console.log("error submit!!");
            return false;
          }
        });
      },
      handleChange(value) {
        console.log(value);
      },
      resetForm(formName) {
        this.$refs[formName].resetFields();
      },
    },
    mounted() {
      
      axios.get('/api/Department/List').then(m => {
        var reg = new RegExp('\\,"children":\\[]', 'g')
        this.options = JSON.parse(JSON.stringify(m.data).replace(reg, ''))
      });
    }
  };
</script>

<style scoped>
  .el-form {
    width: 60%;
  }
</style>