import React from 'react'
import DOMPurify from 'dompurify'
import { useAuth0 } from '@auth0/auth0-react'

//Hook
import UseForm from './UseForm.js'

//Validation
import FormValidation from './FormValidation.js'

const PostsForm = () => {

    //UseForm handles changes and submit of the form
    const { handleChange, handleSubmit, formValues, formErrors } = UseForm(submitPost, FormValidation)
    const { getAccessTokenSilently } = useAuth0();

    function submitPost() {
        let jsonPost = JSON.stringify({
            postTitle: DOMPurify.sanitize(formValues.postTitle),
            postBody: DOMPurify.sanitize(formValues.postBody),
            imageUrl: DOMPurify.sanitize(formValues.imageUrl)
        })

        async function postPost() {
            let result;
            const connErrors = document.getElementById('connError');
            const saveSuccess = document.getElementById('saveSuccess');
            const aToken = await getAccessTokenSilently({ audience: process.env.REACT_APP_AUTH0_AUDIENCE });

            try {
                result = await fetch('https://localhost:7222/api/Posts', {
                    method: 'post',
                    headers: {
                        'content-Type': 'application/json',
                        'authorization': `bearer ${aToken}`
                    },
                    body: jsonPost
                });
            } catch (e) {
                console.log(e);
            }
            if (result === undefined) {
                connErrors.classList.add('d-block')
            } else {
                if (result.status === 201) {
                    console.log("created")
                    connErrors.classList.add('d-none')
                    saveSuccess.classList.add('d-block')
                    setTimeout(() => {
                        window.location.reload()
                    }, 5000);
                } else {
                    connErrors.classList.add('d-block')
                }
            }
        }
        postPost();
    }

    return (
        <>
            <form onSubmit={handleSubmit}>
                <div className='input-comp'>
                    <label htmlFor="">Post title</label>
                    <input id='postTitle' name='postTitle' className='shadow' type="text" value={formValues.postTitle} onChange={handleChange} />
                    {formErrors.postTitle && <small className="text-danger ms-1">{formErrors.postTitle}</small>}
                </div>
                <div className='input-comp'>
                    <label htmlFor="">Post</label>
                    <textarea id='postBody' name='postBody' className='shadow' type="text" value={formValues.postBody} onChange={handleChange} />
                    {formErrors.postBody && <small className="text-danger ms-1">{formErrors.postBody}</small>}
                </div>
                <div className='input-comp'>
                    <label htmlFor="">Image URL</label>
                    <input id='imageUrl' name='imageUrl' className='shadow' type="text" value={formValues.imageUrl} onChange={handleChange} />
                    {formErrors.imageUrl && <small className="text-danger ms-1">{formErrors.imageUrl}</small>}
                </div>
                <button className='shadow' id='submitPost'>Submit</button>
                <div id='connError' className='connError shadow'>
                    <span id='connErrorText'>Database connection error. Save not completed.</span>
                </div>
                <div id='saveSuccess' className='saveSuccess shadow'>
                    <span id='saveSuccessText'>Your post was succesfully saved.</span>
                </div>
            </form>
        </>
    )
}

export default PostsForm