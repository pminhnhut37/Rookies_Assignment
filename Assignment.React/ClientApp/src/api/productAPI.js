import { host } from "../config.js";
const url_product = `${host}/Products`;

export const GetProducts = () => {
    return axios.get(url_product);
};

export const PostProducts = async (FormData) => {
    try {
        const response = await axios({
            method: "post",
            url: url_product,
            data: FormData,
        });
        return response.data;
    } catch (error) {
        console.log(error.response);
        return null;
    }
};

export const PutProducts = async (FormData) => {
    try {
        const response = await axios({
            method: "put",
            url: url_product + "/" + FormData.get("productId"),
            data: FormData,
        });
        return response.data;
    } catch (error) {
        console.log(error.response);
        return null;
    }
};

export const DeleteProduct = async (id) => {
    try {
        return await axios({
            method: "delete",
            url: url_product + "/" + id,
        }).then((_) => true);
    } catch (error) {
        return false;
    }
};