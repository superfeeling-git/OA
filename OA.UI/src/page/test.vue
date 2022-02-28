<template>
    <div>

    </div>
</template>

<script>
    import axios from '@/axios'
    export default {
        data() {
            return {

            }
        },
        mounted() {
            axios.get("/api/identity/roles/all").then(m => {

            });
        },
    }
</script>