import React, { useState, useContext, useEffect } from 'react';
import { Table, Button } from 'reactstrap';
import axios from 'axios';
import { TrashFill } from 'react-bootstrap-icons'
import { ProductContext } from './model.js';
import { host } from '../../config';
import { Link } from 'react-router-dom';

const Product = () => {
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);
  const [productItems, setProduct] = useState([]);

  useEffect(() => {
    fetchProductData();
  }, []);

  const fetchProductData = () => {
    axios.get(host + "/Products")
      .then(response => {
        console.log(response.data);
        setProduct(response.data);
      }).catch((error) => {
        console.log('Get Products Error', error);
      });
  }
  const DeleteProduct = (id) => {
    return axios({
      method: "delete",
      url: host + "/Products/" + id,
    })
      .then((response) => {
        fetchProductData();
        console.log(response.data)
      })
      .catch((error) => {
        console.log(error.response);
        return null;
      });
  };

  return (
    <>
      <h2 className="text-center p-3">List Product</h2>
      <Button color="success" className='mb-2 ml-2'>
        <Link className="text-decoration-none text-white"
          to='/addProduct_form'>
          Add Product
                </Link>
      </Button>

      <Table dark>
        <thead className="text-center">
          <tr>
            <th>Id Product</th>
            <th className="w-25">Name Product</th>
            <th className="w-25">Description</th>
            <th>CategoryID</th>
            <th>Price</th>
            <th>Product Image</th>
            <th>Rate</th>
          </tr>
        </thead>
        <tbody className="text-center">
          {
            productItems && productItems.map(product =>
              <tr key={product.idProduct}>
                <td>{product.idProduct}</td>
                <td>{product.nameProduct}</td>
                <td>{product.productDescription}</td>
                <td>{product.idCate}</td>
                <td>{product.price}$</td>
                <td>
                  <img src={product.image} alt={product.nameProduct} width="150px"></img>
                </td>
                <td>{product.rateStar}</td>
                <td>
                  <Button color="danger" className="mr-2" onClick={async () => await DeleteProduct(product.idProduct)}>
                    <TrashFill color="white" size={20} />
                  </Button>
                </td>
              </tr>
            )
          }
        </tbody>
      </Table>
    </>
  )
}
export default Product;