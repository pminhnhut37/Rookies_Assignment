import axios from "axios";
import { host } from '../config.js';

const url_category = `${host}/Categories`;

export const GetCategories = (setCategoryItem) => {

    return axios.get(url_category)
        .then(response => {
            setCategoryItem(response.data);
        }).catch((error) => {
            console.log('Get Categories Error', error);
        });;
};

export const PostCategory = (FormData) => {
    return axios({
        method: "post",
        url: url_category,
        data: FormData,
    })
        .then((response) => {
            return response.data;
        })
        .catch((error) => {
            console.log(error.response);
            return null;
        });
};

export const PutCategory = (FormData) => {
    return axios({
        method: "put",
        url: url_category + "/" + FormData.get("categoryId"),
        data: FormData,
    })
        .then((response) => {
            return response.data;
        })
        .catch((error) => {
            console.log(error.response);
            return null;
        });
};

export const DeleteCategory = async (id) => {
    try {
        return await axios({
            method: "delete",
            url: url_category + "/" + id,
        }).then((_) => true);
    } catch (error) {
        return false;
    }
};