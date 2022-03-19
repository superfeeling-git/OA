<script>
    export default {        
        render(h) {
            return h(
                'a',
                {
                    style:{
                        color:'blue',
                        fontSize:'18px'
                    },
                    attrs:{
                        id:this.aid,
                        onclick:'alert(1)',
                        href:'javascript:;'
                    }
                },
                '测试'
            )
        },
        props:{
            aid:String,
            default:""
        }
    }
</script>