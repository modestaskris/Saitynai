<template>
  <!-- Modal toggle -->
  <button @click="(e) => onModalClick(e)" class="
      block
      text-white
      bg-green-500
      hover:bg-green-600
      focus:ring-4 focus:outline-none focus:ring-green-300
      font-medium
      rounded-lg
      text-sm
      p-2
      text-center
    " type="button" data-modal-toggle="authentication-modal">
    <font-awesome-icon icon="fa-solid fa-pen" />
    Edit
  </button>

  <!-- Main modal -->
  <div @click="clickedBackground" :class="{ hidden: displayModal }" id="authentication-modal" tabindex="-1"
    aria-hidden="true" class="
      overflow-y-auto overflow-x-hidden
      flex
      justifty-center
      fixed
      top-0
      right-0
      left-0
      z-50
      w-full
      md:inset-0
      h-modal
      md:h-full
    ">
    <div class="relative p-4 w-full flex justify-center h-fit">
      <!-- Modal content -->
      <div @click="preventBubbles" class="relative bg-white rounded-lg shadow dark:bg-gray-700 w-2/4">
        <button @click="onModalClick" type="button" class="
            absolute
            top-3
            right-2.5
            text-gray-400
            bg-transparent
            hover:bg-gray-200 hover:text-gray-900
            rounded-lg
            text-sm
            p-1.5
            ml-auto
            inline-flex
            items-center
            dark:hover:bg-gray-800 dark:hover:text-white
          " data-modal-toggle="authentication-modal">
          <svg aria-hidden="true" class="w-5 h-5" fill="currentColor" viewBox="0 0 20 20"
            xmlns="http://www.w3.org/2000/svg">
            <path fill-rule="evenodd"
              d="M4.293 4.293a1 1 0 011.414 0L10 8.586l4.293-4.293a1 1 0 111.414 1.414L11.414 10l4.293 4.293a1 1 0 01-1.414 1.414L10 11.414l-4.293 4.293a1 1 0 01-1.414-1.414L8.586 10 4.293 5.707a1 1 0 010-1.414z"
              clip-rule="evenodd"></path>
          </svg>
          <span class="sr-only">Close modal</span>
        </button>
        <div class="py-6 px-6 lg:px-8">
          <h3 class="mb-4 text-xl font-medium text-gray-900 dark:text-white">
            Edit {{ modelName }}
          </h3>
          <div class="space-y-6" action="#">
            <!-- Renders only for category type -->
            <div v-if="isCategory">
              <label for="categ" class="
                  block
                  mb-2
                  text-sm
                  font-medium
                  text-gray-900
                  dark:text-gray-300
                ">Type {{ modelName }} new name:</label>
              <input v-model="newModelName" type="text" id="categ" class="
                  bg-gray-50
                  border border-gray-300
                  text-gray-900 text-sm
                  rounded-lg
                  focus:ring-blue-500 focus:border-blue-500
                  block
                  w-full
                  p-2.5
                  dark:bg-gray-600
                  dark:border-gray-500
                  dark:placeholder-gray-400
                  dark:text-white
                " placeholder="" required />
            </div>
            <div v-else-if="isPlaylist">
              <label for="playlistName" class="
                  block
                  mb-2
                  text-sm
                  font-medium
                  text-gray-900
                  dark:text-gray-300
                ">Type {{ modelName }} new name:</label>
              <input v-model="newModelName" type="text" id="playlistName" class="
                  bg-gray-50
                  border border-gray-300
                  text-gray-900 text-sm
                  rounded-lg
                  focus:ring-blue-500 focus:border-blue-500
                  block
                  w-full
                  p-2.5
                  dark:bg-gray-600
                  dark:border-gray-500
                  dark:placeholder-gray-400
                  dark:text-white
                " placeholder="" required />
              <label for="categ" class="
                  my-4
                  block
                  mb-2
                  text-sm
                  font-medium
                  text-gray-900
                  dark:text-gray-300
                ">Type {{ modelName }} new Url:</label>
              <input v-model="newUrl" type="text" id="categ" class="
                  bg-gray-50
                  border border-gray-300
                  text-gray-900 text-sm
                  rounded-lg
                  focus:ring-blue-500 focus:border-blue-500
                  block
                  w-full
                  p-2.5
                  dark:bg-gray-600
                  dark:border-gray-500
                  dark:placeholder-gray-400
                  dark:text-white
                " placeholder="" required />
            </div>
            <div v-else-if="isSong">
              <label for="song" class="
                  my-4
                  block
                  mb-2
                  text-sm
                  font-medium
                  text-gray-900
                  dark:text-gray-300
                ">Type {{ modelName }} new Url:</label>
              <input v-model="newUrl" type="text" id="song" class="
                  bg-gray-50
                  border border-gray-300
                  text-gray-900 text-sm
                  rounded-lg
                  focus:ring-blue-500 focus:border-blue-500
                  block
                  w-full
                  p-2.5
                  dark:bg-gray-600
                  dark:border-gray-500
                  dark:placeholder-gray-400
                  dark:text-white
                " placeholder="" required />
            </div>
            <div v-else>{{ modelType }} - is not implemented....</div>
            <!-- type="submit" -->
            <button @click="onUpdateModel" class="
                w-full
                text-white
                bg-blue-700
                hover:bg-blue-800
                focus:ring-4 focus:outline-none focus:ring-blue-300
                font-medium
                rounded-lg
                text-sm
                px-5
                py-2.5
                text-center
                dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800
              ">
              Update
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
    
<script lang="ts">
import type { ICategory } from "@/models/category/category";
import { CategoryService } from "@/services/categoryService";
import { defineComponent } from "@vue/runtime-core";

export default defineComponent({
  props: {
    modelName: String,
    modelType: String,
  },
  emits: ["editModelPressed", "modalActivation"],
  data() {
    return {
      displayModal: true as boolean,
      newModelName: "" as string,
      newUrl: "" as string,
    };
  },
  computed: {
    isCategory(): boolean {
      return this.modelType === "category";
    },
    isPlaylist(): boolean {
      return this.modelType === "playlist";
    },
    isSong(): boolean {
      return this.modelType === "song";
    },
  },
  methods: {
    triggerModal() {
      this.displayModal = !this.displayModal;
    },
    onModalClick(e: null | any) {
      if (e !== undefined) {
        e.stopPropagation();
      }
      this.$emit("modalActivation", this.displayModal);
      this.triggerModal();
    },
    async onUpdateModel() {
      if (this.isCategory) {
        if (this.newModelName == "") {
          this.showError();
          return;
        }
        this.$emit("modalActivation", this.newModelName);
      } else if (this.isPlaylist) {
        if (this.newModelName == "" || this.newUrl == "") {
          this.showError();
          return;
        }
        this.$emit("editModelPressed", this.newModelName, this.newUrl);
      } else if (this.isSong) {
        if (this.newUrl == "") {
          this.showError();
          return;
        }
        this.$emit("editModelPressed", "empty first param", this.newUrl);
      } else {
        throw Error("type not found: " + this.modelType);
        // TODO emit not implemented.. or throw error
      }
      this.clearData();
      this.onModalClick(undefined);
    },
    clearData() {
      this.newModelName = ""; // clears old data
      this.newUrl = "";
    },
    showError() {
      throw Error("Input data is empty...");
    },
    preventBubbles(e: any) {
      e.stopPropagation();
    },
    clickedBackground() {
      if (!this.displayModal) {
        this.triggerModal();
      }
    }
  },
});
</script>