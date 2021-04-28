import React, { useState, useContext, useEffect } from 'react';
import { Table, Button } from 'reactstrap';
import { TrashFill } from 'react-bootstrap-icons';
import { Pen } from 'react-bootstrap-icons';
import { Link } from 'react-router-dom';
import { DeleteProduct, GetProducts, PutProducts } from '../../api/productAPI.js';

const Product = () => {
  const [modal, setModal] = useState(false);
  const toggle = () => setModal(!modal);
  const [productItems, setProduct] = useState([]);

  useEffect(() => {
    fetchProductData();
  }, []);

  const fetchProductData = () => {
    GetProducts(setProduct)
  }

  return (
    <>
      <h2 className="text-center p-3">List Product</h2>
      <Button color="success" className='mb-2 ml-2'>
        <Link className="text-decoration-none text-white" to="/addProducts">
          Add Product
                </Link>
      </Button>

      <Table dark>
        <thead className="text-center">
          <tr>
            <th>Id Product</th>
            <th>Name Product</th>
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
                <td>{product.rateStar.toFixed(1)}</td>
                <td>
                  <Button color="success" className="mr-2">
                    <Link to={{
                      pathname: '/addProducts/' + product.idProduct,
                      idProduct: product.idProduct,
                      product: {
                        idProduct: product.idProduct,
                        nameProduct: product.nameProduct,
                        productDescription: product.productDescription,
                        idCate: product.idCate,
                        price: product.price,
                        images: product.image,
                      }
                    }}>
                      <Pen color="white" size={20} />
                    </Link>
                  </Button>
                </td>
                <td>
                  <Button color="danger" className="mr-2" onClick={async () => await DeleteProduct(product.idProduct).then(fetchProductData)}>
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