<template>
  <div class="d-flex justify-content-center align-items-center vh-100">
    <div class="card p-4 shadow" style="max-width: 400px; width: 100%">
      <h3 class="text-center">Formulario de creación de países</h3>

      <form @submit.prevent="saveCountry">
        <div class="form-group">
          <label for="name">Nombre:</label>
          <input
            v-model="formData.Name"
            type="text"
            id="name"
            class="form-control"
            required
          />
        </div>

        <div class="form-group">
          <label for="continent">Continente:</label>
          <select
            v-model="formData.Continent"
            id="continent"
            class="form-control"
            required
          >
            <option value="" disabled>Seleccione un continente</option>
            <option>África</option>
            <option>Asia</option>
            <option>Europa</option>
            <option>América</option>
            <option>Oceanía</option>
            <option>Antártida</option>
          </select>
        </div>

        <div class="form-group">
          <label for="language">Idioma:</label>
          <input
            v-model="formData.Language"
            type="text"
            id="language"
            class="form-control"
            required
          />
        </div>

        <div class="mt-3">
          <button type="submit" class="btn btn-success btn-block">
            Guardar
          </button>
        </div>
      </form>

      <div
        v-if="successMessage"
        id="successMessage"
        class="alert alert-success mt-3"
      >
        {{ successMessage }}
      </div>

      <div
        v-if="errorMessage"
        id="errorMessage"
        class="alert alert-danger mt-3"
      >
        {{ errorMessage }}
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "CountryForm",
  data() {
    return {
      formData: {
        Name: "",
        Continent: "",
        Language: "",
      },
      successMessage: "",
      errorMessage: "",
    };
  },
  methods: {
    saveCountry() {
      console.log("Datos a guardar:", this.formData);

      axios
        .post("http://localhost:5296/api/country", {
          Name: this.formData.Name,
          Continent: this.formData.Continent,
          Language: this.formData.Language,
        })
        .then((response) => {
          console.log(response);

          this.successMessage = "País guardado exitosamente.";
          this.errorMessage = "";

          setTimeout(() => {
            window.location.href = "/";
          }, 1500);
        })
        .catch((error) => {
          console.log(error);

          this.errorMessage = "Error al guardar el país.";
          this.successMessage = "";
        });
    },
  },
};
</script>

<style>
</style>