<template>
    <div>
        <el-form :model="ruleForm" ref="ruleForm" label-width="100px" class="demo-ruleForm">
            <el-form-item label="部门名称">
                <el-input v-model="ruleForm.deptName"></el-input>
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
        </el-form>
    </div>
</template>

<script>
    import axios from '@/axios.js'
    export default {
        name:"edit",
        data() {
            return {
                ruleForm: {
                    deptName: "",
                    deptManageName: "",
                    parentId: 0,
                    remark: ""
                },
                tid:0,
                value: [],
                options: []
            };
        },
        props:{
            id:Number
        },
        methods: {
            submitForm(formName) {
                this.$refs[formName].validate((valid) => {
                    if (valid) {
                        console.log('===============')
                        console.log(this.ruleForm);
                        // axios.post('/api/Department/Create', this.ruleForm).then(m => {

                        // });
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
        created() {
            
        },
        mounted() {
            console.log(this.tid);

            axios.get("/api/Department/GetTreeNodes").then(m => {
                var reg = new RegExp('\\,"children":\\[]', 'g')
                this.options = JSON.parse(JSON.stringify(m.data).replace(reg, ''));
            });

            axios.get('/api/Department/GetDepartment?id=' + this.id).then(m => {
                this.ruleForm = m.data;
                this.value = m.data.parentId;
            });
        },
    }
</script>