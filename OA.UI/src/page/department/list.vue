<template>
    <div>
        <el-table :data="tableData" style="width: 100%;margin-bottom: 20px;" row-key="id" border default-expand-all
            :tree-props="{children: 'children', hasChildren: 'hasChildren'}">
            <el-table-column prop="id" label="ID" sortable width="180">
            </el-table-column>
            <el-table-column prop="deptName" label="部门名称" sortable width="180">
            </el-table-column>
            <el-table-column prop="deptManageName" label="部门经理" sortable width="180">
            </el-table-column>
            <el-table-column prop="remark" label="备注" sortable>
            </el-table-column>
            <el-table-column label="操作">
                <template slot-scope="scope">
                    <el-button size="mini" @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
                    <el-button size="mini" type="danger" @click="handleDelete(scope.$index, scope.row)">删除</el-button>
                </template>
            </el-table-column>
        </el-table>

        <el-dialog title="部门编辑" :visible.sync="dialogFormVisible" @close="closeDialog">
            <dept-edit :id="id" v-if="refresh" ref="dept"></dept-edit>
            <div slot="footer" class="dialog-footer">
                <el-button @click="dialogFormVisible = false">取 消</el-button>
                <el-button type="primary" @click="Save">确 定</el-button>
            </div>
        </el-dialog>
    </div>
</template>

<script>
    import axios from '@/axios'
    import DeptEdit from './edit'
    export default {
        name:"list",
        components: {
            DeptEdit
        },
        data() {
            return {
                tableData: [],
                dialogFormVisible: false,
                id: 0,
                refresh:false
            }
        },
        methods: {
            handleEdit(index, row) {
                //弹窗
                this.dialogFormVisible = true;
                this.refresh = true;
                this.id = row.id;
            },
            handleDelete(index, row) {
                console.log(index, row);
            },
            closeDialog(){
                this.refresh = false;
            },
            Save(){
                //this.$refs.dept.submitForm('ruleForm');
                console.log(this.$refs.dept.ruleForm);
                //axios.post('')
                //console.log(this.$refs.dept);
                //this.dialogFormVisible = false;
            }
        },
        mounted() {
            axios.get("/api/Department/GetTableData").then(m => {
                var reg = new RegExp('\\,"children":\\[]', 'g')
                this.tableData = JSON.parse(JSON.stringify(m.data).replace(reg, ''));
            });
        },
    }
</script>