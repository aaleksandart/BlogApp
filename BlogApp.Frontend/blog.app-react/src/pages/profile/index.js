import { withAuthenticationRequired } from '@auth0/auth0-react'
import React from 'react'

//Components
import UserProfile from '../../components/shared/UserProfile.js'
import Load from '../../components/shared/Load.js'

const index = () => {
  return (
    <>
        <div className='profile-page'>
            <UserProfile />
        </div>
    </>
  )
}

export default withAuthenticationRequired(index, {
  onRedirecting: () => <Load />
})