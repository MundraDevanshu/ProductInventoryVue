import { createStore } from "vuex";
import axios from "axios";
import { URLS } from "@/constant/Constant.js";

const store = createStore({
  state: () => ({
    products: [],
    totalCount: 0,
  }),

  getters: {},

  actions: {
    async fetchProducts({ commit }, { currentPage, pageSize }) {
      const response = await axios.get(
        `https://localhost:44337/api/Product/productResult?pageNumber=${currentPage}&pageSize=${pageSize}`
      );
      console.log(response.data);
      commit("setProducts", response.data);
    },
    async searchProducts({ commit }, { searchTerm, currentPage, pageSize }) {
      const response = await axios.get(
        `https://localhost:44337/api/Product/searchPage?title=${searchTerm}&pageNumber=${currentPage}&pageSize=${pageSize}`
      );
      commit("setProducts", response.data);
    },

    async deleteProduct({ commit, dispatch }, id) {
      const response = await axios.delete(`${URLS.GET_URL}` + "?id=" + `${id}`);
      dispatch("fetchProducts");
      commit("remove", { id });
    },

    async addProduct({ commit }, payload) {
      console.log(payload);
      const response = await axios.post(`${URLS.GET_URL}`, payload);
      commit("addProduct", payload);
    },
    async editProduct({ commit }, payload) {
      console.log(payload);
      const response = await axios.put(
        `${URLS.GET_URL}` + "?id=" + payload.id,
        payload
      );
      commit("update", response.data);
    },
    async getById({ commit }, id) {
      const response = await axios.get(`${URLS.GET_URL}` + "/" + id);
      console.log(response.data);
      commit("setProducts", response.data);
      return response.data;
    },
  },

  mutations: {
    setProducts: (state, data) => {
      state.products = data.products;
      state.totalCount = data.totalCount;
      console.log(data);
    },
    remove(state, id) {
      state.products = this.state.products.filter((i) => i.id !== id.id);
    },
    update(state, data) {
      // router.push({name:"Pagination"});
    },
    addProduct(state, payload) {
      // router.push("/product");
    },
  },
});

export default store;
