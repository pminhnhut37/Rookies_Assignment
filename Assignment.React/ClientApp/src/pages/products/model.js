import React, {createContext, useEffect, useState} from 'react';

export const ProductContext = createContext({});

const ProductContextProvider = ({children}) => {
    const [productItems, setProductItems] = useState([]);

    useEffect(() => {

    }, []);

    return (
        <ProductContext.Provider values={{
            productItems
        }}>
            {children}
        </ProductContext.Provider>
        
    );
};
export default ProductContextProvider;