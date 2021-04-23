import axios from 'axios';

const basehost = 'https://localhost:5001';


export const GetProduct = () => {
    return axios.get(basehost + '/Products').then(response => response.data).catch((error) => {
        console.log(error.response);
        return [];
    });
}; 