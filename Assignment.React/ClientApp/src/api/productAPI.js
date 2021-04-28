import axios from "axios";
import { host } from "../config.js";
const url_product = `${host}/Products`;

export const GetProducts = (setProduct) => {
  return axios
    .get(url_product)
    .then((response) => {
      console.log(response.data);
      setProduct(response.data);
    })
    .catch((error) => {
      console.log("Get Products Error", error);
    });
};

export const PostProducts = async (setProduct, FormData) => {
  axios
    .post(url_product, FormData)
    .then((response) => {
      setProduct(response.data);
    })
    .catch((error) => {
      console.log(error.response);
      return null;
    });
};

export const PutProducts = async (id, FormData, setProduct) => {
  return axios({
    method: "put",
    url: url_product + "/" + id,
    data: FormData,
  })
    .then((response) => {
      setProduct(response.data);
      console.log(response.data);
    })
    .catch((error) => {
      console.log(error.response);
      return null;
    });
};

export const DeleteProduct = async (id) => {
  return axios({
    method: "delete",
    url: url_product + "/" + id,
  })
    .then((response) => {
      console.log(response.data);
    })
    .catch((error) => {
      console.log(error.response);
      return null;
    });
};
