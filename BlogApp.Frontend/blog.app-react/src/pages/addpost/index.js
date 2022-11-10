import React from 'react'
import PostsForm from '../../components/forms/PostsForm.js'

const index = () => {
    return (
        <>
            <div className='form-page'>
                <div className='form-container shadow'>
                    <h3>Create post</h3>
                    <PostsForm />
                </div>
            </div>
        </>
    )
}

export default index