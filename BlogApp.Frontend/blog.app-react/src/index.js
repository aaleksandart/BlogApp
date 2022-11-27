import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import Auth0 from './auth/Auth0.js'
import { BrowserRouter } from 'react-router-dom';

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <Auth0>
        <App />
      </Auth0>
    </BrowserRouter>
  </React.StrictMode>
);
