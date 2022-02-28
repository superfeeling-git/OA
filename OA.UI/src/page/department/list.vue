<template>
    <div>
        <el-table :data="tableData" style="width: 100%;margin-bottom: 20px;" row-key="value" border default-expand-all
            :tree-props="{children: 'children', hasChildren: 'hasChildren'}">
            <el-table-column prop="value" label="ID" sortable width="180">
            </el-table-column>
            <el-table-column prop="label" label="部门名称" sortable width="180">
            </el-table-column>
        </el-table>
    </div>
</template>

<script>
    import axios from '@/axios'
    export default {
        data() {
            return {
                tableData: []
            }
        },
        mounted() {
            axios.get("/api/Department/List").then(m => {
                var reg = new RegExp('\\,"children":\\[]', 'g')
                this.tableData = JSON.parse(JSON.stringify(m.data).replace(reg, ''));
            });
        },
    }
</script>