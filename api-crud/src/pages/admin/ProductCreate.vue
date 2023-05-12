<template>
  <form>
    <label>Name</label>
    <input
      type="text"
      class="form-control"
      placeholder="Product Name"
      name="title"
      v-model="title"
    />
    <label>Description</label>
    <input
      type="text"
      class="form-control"
      placeholder="Description"
      name="description"
      v-model="description"
    />
    <label>Category</label>
    <input
      type="text"
      class="form-control"
      placeholder="Category"
      name="category"
      v-model="category"
    />
    <label>Price</label>
    <input
      type="number"
      class="form-control"
      placeholder="Price"
      name="price"
      v-model="price"
    />

    <button type="button" class="btn btn-success mt-2" @click.prevent="addProduct()">
      Add
    </button>
    <button type="button" class="btn btn-danger mt-2 mx-3" @click.prevent="clearFormButton()">
      Clear
    </button>
    <button type="button" class="btn btn-primary mt-2" @click.prevent="cancelButton()">
      Cancel
    </button>
    
  </form>
</template>

<script>
export default {
  name: "ProductCreate",
  data() {
    return {
      title: "",
      description: "",
      category:"",
      price: "",
    };
  },
  methods: {
    async addProduct() {
      let resul = await this.$store.dispatch("addProduct", {
        title: this.title,
        description: this.description,
        category: this.category,
        price: this.price,
      });
      this.$router.push({name:"Pagination"});
      // console.log("check", resul);
    },
    clearFormButton(){
      this.title= "",
      this.description="",
      this.category="",
      this.price=""
    },
    cancelButton(){
        this.$router.push({name:"Pagination"});
    },
  },
};
</script>

<style></style>
