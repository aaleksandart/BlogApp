import React from 'react'
import { useAuth0 } from '@auth0/auth0-react';

const UserProfile = () => {

  const { logout, user, isAuthenticated } = useAuth0();
  return (
    <>
      <div className='user-profile-container shadow'>
        <h3>Profile</h3>
        {
          isAuthenticated &&
          <div className='user-info'>
            <h4>{user.name}</h4>
            <div className='profile-image-container'>
              <img src={user.picture} alt={user.name} />
            </div>
            <p>{user.email}</p>
            <button className='navy-btn shadow' onClick={() => logout({ returnTo: window.location.origin })}>Logout</button>
          </div>
        }
      </div>
    </>
  )
}

export default UserProfile