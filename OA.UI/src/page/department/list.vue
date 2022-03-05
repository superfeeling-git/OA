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

        <el-dialog title="部门编辑" :visible.sync="dialogFormVisible" :key="new Date().getTime()">
            <dept-edit :id="id"  ref="dept"></dept-edit>
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
    import bus from '@/bus'
    export default {
        name:"list",
        components: {
            DeptEdit
        },
        data() {
            return {
                tableData: [],
                dialogFormVisible: false,
                id: 0
            }
        },
        methods: {
            handleEdit(index, row) {
                //弹窗
                this.dialogFormVisible = true;
                this.id = row.id;
            },
            handleDelete(index, row) {
                console.log(index, row);
            },
            closeDialog(){

            },
            Save(){
                var _this = this;
                //bus.$emit('on-send');
                //this.$refs.dept.submitForm('ruleForm');
                
                axios.post('/api/Department/Update',this.$refs.dept.ruleForm).then(m=>{
                    this.$message({
                        message: '更新成功',
                        type: 'success',
                        onClose: function () {
                            _this.dialogFormVisible = false;
                            _this.reLoad();
                        }
                    });
                });
                //console.log(this.$refs.dept);
                //this.dialogFormVisible = false;
            },
            reLoad(){
                axios.get("/api/Department/GetTableData").then(m => {
                var reg = new RegExp('\\,"children":\\[]', 'g')
                this.tableData = JSON.parse(JSON.stringify(m.data).replace(reg, ''));
            });
            }
        },
        mounted() {
            this.reLoad();
        },
    }
</script>