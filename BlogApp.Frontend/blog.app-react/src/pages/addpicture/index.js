import { withAuthenticationRequired } from '@auth0/auth0-react'
import React from 'react'

//Components
import PictureForm from '../../components/forms/PictureForm.js'
import Load from '../../components/shared/Load.js'

const index = () => {
    return (
        <>
            <div className='add-picture-page'>
                <div className='add-picture-container shadow'>
                    <h3>Upload picture</h3>
                    <PictureForm />
                </div>
            </div>
        </>
    )
}

export default withAuthenticationRequired(index, {
    onRedirecting: () => <Load />
})