<template>
    <div>
        <el-form :model="ruleForm" ref="ruleForm" label-width="100px" class="demo-ruleForm">
            <el-form-item label="部门名称">
                <el-input v-model="ruleForm.DeptName"></el-input>
            </el-form-item>
            <el-form-item label="上级部门">
                <el-cascader style="width: 360px;" :props="{ checkStrictly: true }" clearable v-model="value"
                    :options="options" @change="handleChange"></el-cascader>
            </el-form-item>
            <el-form-item label="部门负责人">
                <el-input v-model="ruleForm.deptManageName"></el-input>
            </el-form-item>
            <el-form-item label="备注">
                <el-input type="textarea" v-model="ruleForm.remark" :rows="8"></el-input>
            </el-form-item>

            <el-form-item>
                <el-button type="primary" @click="submitForm('ruleForm')">立即创建</el-button>
                <el-button @click="resetForm('ruleForm')">重置</el-button>
            </el-form-item>
        </el-form>
    </div>
</template>

<script>
    import axios from '@/axios.js'
    export default {
        data() {
            return {
                ruleForm: {
                    DeptName: "",
                    deptManageName: "",
                    parentId: 0,
                    remark: ""
                },
                value: [],
                options: []
            };
        },
        methods: {
            submitForm(formName) {
                this.$refs[formName].validate((valid) => {
                    if (valid) {
                        axios.post('/api/Department/Create', this.ruleForm).then(m => {

                        });
                    } else {
                        console.log("error submit!!");
                        return false;
                    }
                });
            },
            handleChange(value) {
                //获取数组的最后一个元素，赋值parentId
                console.log(value);
                this.ruleForm.parentId = value[value.length - 1];
            },
            resetForm(formName) {
                this.$refs[formName].resetFields();
            },
        },
        mounted() {
            axios.get("/api/Department/List").then(m => {
                var reg = new RegExp('\\,"children":\\[]', 'g')
                this.options = JSON.parse(JSON.stringify(m.data).replace(reg, ''));
            });
        },
    };
</script>

<style scoped>
    .el-form {
        width: 60%;
    }
</style>