<script>
  export default {
    components: {
      com: () => import('./comb'),
      modelHeader: {
        template: `<div>头部</div>`
      }
    },
    data() {
      return {
        num: 1
      };
    },
    render(h) {
      return h(
        "div",
        {

        },
        [
          h(
            'modelHeader',
            {
              props: {
                aid: "6"
              }
            },

          )
        ]
      )
    },
    methods: {
      handleChange(currentValue, oldValue, str) {
        console.log(currentValue);
        console.log(oldValue);
        console.log(str);
      }
    }
  };
</script>