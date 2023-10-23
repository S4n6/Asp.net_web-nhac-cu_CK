import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.jsx'
import Contact from './pages/Contact.jsx'
import LoginForm from './pages/LoginForm.jsx'
import Product from './pages/Product.jsx'
import ProductView from './pages/ProductView.jsx'
import CategoryFilter from './pages/CategoryFilter.jsx'

import './index.css'
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";

const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>,
  },
  {
    path: "contact",
    element: <Contact/>,
  },
  {
    path: "login",
    element: <LoginForm/>,
  },
  {
    path: "product/:productId",
    element: <ProductView/>,
  },
  {
    path: "category",
    element: <CategoryFilter/>,
  },
  
]);

ReactDOM.createRoot(document.getElementById('root')).render(
  <React.StrictMode>
    <RouterProvider router={router} />  
  </React.StrictMode>,
)
