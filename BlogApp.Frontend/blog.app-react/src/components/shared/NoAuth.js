import React from 'react'
import { useAuth0 } from '@auth0/auth0-react';

const NoAuth = () => {
    const { loginWithRedirect } = useAuth0();
    return (
        <>
            <div className='no-auth-container'>
                <h4>You need to login to access this page.</h4>
                <button className='navy-btn' onClick={() => loginWithRedirect()}>Login</button>
            </div>
        </>
    )
}

export default NoAuth