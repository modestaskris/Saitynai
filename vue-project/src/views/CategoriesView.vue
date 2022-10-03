<script setup lang="ts">
import route from '../router/route';

</script>

<template>
  <div>
    <AddModel @createButtonPressed="addNewCategory" modelType="category" />
    <hr />
    <div>
      <ModelRow
        v-for="playlist in categories"
        v-bind:key="playlist.categoryId"
        @deleteModel="deleteCategoryFromCategories"
        @editModel="updateCategory"
        :modelId="playlist.categoryId"
        :name="playlist.name"
        :routeRoot="route.CATEGORIES"
        modelType="category"
      />
    </div>
  </div>
</template>

<script lang="ts">
import Category from "../components/categories/Category.vue";
import { defineComponent } from "vue";
import { CategoryService } from "@/services/categoryService";
import AddModel from "../components/AddModel.vue";
import ModelRow from "../components/ModelRow.vue";

interface ICategory {
  categoryId: number;
  name: string;
}

export default defineComponent({
  data() {
    return {
      categories: [] as ICategory[],
      apiError: {
        occured: false as boolean,
        errorCode: -1 as number,
        errorMessage: "" as string,
      },
    };
  },
  async mounted() {
    this.fetchCategories();
  },
  watch: {
    apiError() {
      // TODO implement error handling...
      console.log(`ApiError changed: ${this.apiError}`);
    },
  },
  methods: {
    async fetchCategories() {
      const resp = await CategoryService.getList();
      if (resp.status === 200) {
        this.categories = resp.data;
      } else {
        this.apiError.occured = true;
        this.apiError.errorCode = resp.status;
        this.apiError.errorMessage = resp.statusText;
      }
    },
    async addNewCategory(categName: string) {
      const resp = await CategoryService.create({
        name: categName,
      });
      console.log(resp);
      if (resp.status == 201) {
        this.categories.push(resp.data);
      } else if (resp.status != 200) {
        console.error("Error ocured while creating new category");
        // TODO show error
      }
    },
    async deleteCategoryFromCategories(id: Number) {
      const resp = await CategoryService.delete(id);
      console.log(resp);
      if (resp.status === 204) {
        this.categories = this.categories.filter((x) => x.categoryId !== id);
      } else {
        // TODO: implement error handling...
        console.error("Delete didnt work");
      }
    },
    async updateCategory(categId: Number, newName: string){
      console.log(categId);
      const obj = this.categories.find(x => x.categoryId === categId);
      const resp = await CategoryService.update(categId, {
        name: newName
      });
      console.log(resp);
      if(resp.status === 204){
        // success... replace old data with new...
        // TODO: 
        this.categories = this.categories.map(x => {
          if(x.categoryId == categId){
            x.name = newName
          }
          return x;
        })
      } else {
        // TODO: throw error
      }
    }
  },
  components: { Category, AddModel, ModelRow },
});
</script>