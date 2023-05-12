<template>
  <div>
    <div class="input-group">
      <input
        style="width: 35%"
        type="text"
        v-model="searchTerm"
        placeholder="Search Product"
      />
    </div>

    <div class="table-wrapper-scroll-y my-custom-scrollbar">
      <table class="table table-bordered table-striped mb-0">
        <thead>
          <tr>
            <th scope="col">Name</th>
            <th scope="col">Description</th>
            <th scope="col">Category</th>
            <th scope="col">Price</th>
            <th scope="col">Discount</th>
            <th scope="col">Actions</th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="product in products" :key="product.id">
            <td>{{ product.title }}</td>
            <td>{{ product.description }}</td>
            <td>{{ product.category }}</td>
            <td>{{ product.price }}</td>
            <td>{{ product.discount }}</td>
            <td>
              <fa class="edit_icon" icon="edit" @click="edit(product.id)"></fa>
              <fa
                class="delete_icon"
                icon="trash"
                @click="deleteProduct(product.id)"
              ></fa>
            </td>
          </tr>
        </tbody>
      </table>
    </div>
    <div v-if="totalPages === 0">
      <h2 class="not_found">Product Not Found!</h2>
    </div>

    <div v-else style="float: right" class="pagination">
      <button
        class="pgn_btn"
        @click="previousPage"
        :disabled="currentPage == 1"
      >
        <fa icon="backward"></fa>
      </button>
      <select class="pgn_btn" v-model="pageSize" @change="updatePageSize">
        <option v-for="size in pageSizes" :value="size" :key="size">
          {{ size }}
        </option>
      </select>
      <button
        class="pgn_btn"
        @click="nextPage"
        :disabled="
          currentPage == Math.ceil(totalPages / pageSize) || totalPages == 0
        "
      >
        <fa icon="forward"></fa>
      </button>
    </div>
  </div>
</template>
<script>
export default {
  name: "Pagination",
  data() {
    return {
      products: [],
      currentPage: 1,
      totalPages: 1,
      pageSize: 10,
      pageSizes: [10, 20, 30],
      searchTerm: "",
    };
  },
  computed: {
    startIndex() {
      return (this.currentPage - 1) * this.pageSize;
    },
    endIndex() {
      return this.startIndex + this.pageSize;
    },
  },
  watch: {
  searchTerm: function(newValue) {
    this.searchTerm=newValue;
    this.fetchProducts(this.searchTerm);
  }
},
  methods: {
    edit(id) {
      this.$router.push({ name: "ProductEdit", params: { id: id } });
    },
    async deleteProduct(id) {
      if (confirm("Are you Sure , You want to Delete?")) {
        await this.$store.dispatch("deleteProduct", id);
        this.fetchProducts(this.pageNumber, this.pageSize);
      }
    },
    async fetchProducts() {
      if (this.searchTerm == "") {
        await this.$store.dispatch("fetchProducts", {
          pageSize: this.pageSize,
          currentPage: this.currentPage,
        });
      } else {
        await this.$store.dispatch("searchProducts", {
          searchTerm: this.searchTerm,
          pageSize: this.pageSize,
          currentPage: this.currentPage,
        });
      }
      this.products = this.$store.state.products;
      this.totalPages = this.$store.state.totalCount;
    },
    previousPage() {
      console.log("clicked previous");
      if (this.currentPage > 1) {
        this.currentPage--;
        this.fetchProducts();
      }
    },
    nextPage() {
      if (this.currentPage < this.totalPages) {
        this.currentPage++;
        this.fetchProducts();
      }
    },
    updatePageSize(event) {
      this.pageSize = parseInt(event.target.value, 10);
      this.currentPage = 1;
      this.fetchProducts();
    },
  },
  created() {
    this.fetchProducts();
  },
};
</script>
