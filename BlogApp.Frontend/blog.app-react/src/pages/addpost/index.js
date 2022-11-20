import { withAuthenticationRequired } from '@auth0/auth0-react'
import PostsForm from '../../components/forms/PostsForm.js'

//Components
import Load from '../../components/shared/Load.js'

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

export default withAuthenticationRequired(index, {
    onRedirecting: () => <Load/>
})