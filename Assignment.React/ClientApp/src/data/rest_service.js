import axios from "axios";

const basehost =
  "https://backend7b2a6923a77146aaaf2982a93e78d242.azurewebsites.net";

export const GetProduct = () => {
  return axios
    .get(basehost + "/Products")
    .then((response) => response.data)
    .catch((error) => {
      console.log(error.response);
      return [];
    });
};
