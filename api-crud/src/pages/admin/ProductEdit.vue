<template>
  <form >
    <label>Title</label>
    <input type="text" name="title" v-model="title" />
    <label>Description</label>
    <input type="text" name="description" v-model="description" />
    <label>Category</label>
    <input type="text" name="category" v-model="category" />
    <label>Price</label>
    <input type="number" name="price" v-model="price" />
    <button class="mt-4 btn btn-success" @click.prevent="updatechange()">Update</button>
    <button type="button" class="btn btn-danger mt-4 mx-3" @click.prevent="cancelButton()">Cancel</button>
  </form>
</template>
<script>
import { useRoute } from "vue-router";
export default {
  name: "ProductEdit",
  data() {
    return {
      title: "",
      description: "",
      category:"",
      price: "",
      id: "",
      product: {},
    };
  },
  methods: {
    async updatechange() {
      await this.$store.dispatch("editProduct", {
        id: this.id,
        title: this.title,
        description: this.description,
        category: this.category,
        price: this.price,
      });
      this.$router.push({name:"Pagination"});
    },
    cancelButton(){
        this.$router.push({name:"Pagination"});
    }
  },

  async mounted() {
    const route = useRoute();
    this.product = await this.$store.dispatch("getById", route.params.id);
    this.title = this.product.title;
    this.description = this.product.description;
    this.category=this.product.category;
    this.price=this.product.price;
    this.id = this.product.id;
  },
};
</script>

<style></style>
