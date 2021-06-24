using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Zenra
{
    namespace Player
    {
        public class PlayerAnimation : MonoBehaviour, IPlayerChangeFixedTime
        {
            private PlayerCore _core;
            private Animator _animator;

            private PlayerAnimState _state;
            private PlayerAnimStateExecutionMethod _animMethod;
            private int _stateHash;

            private bool _playedOneShot = false;
            private float _fixedTime;

            private Dictionary<PlayerAnimState, PlayerAnimStateExecutionMethod> _animStateMethods 
              = new Dictionary<PlayerAnimState, PlayerAnimStateExecutionMethod>() {
                { PlayerAnimState.IDLE,         PlayerAnimStateExecutionMethod.PLAY_ONE_SHOT},
                { PlayerAnimState.RUN,          PlayerAnimStateExecutionMethod.PLAY_ONE_SHOT },
                { PlayerAnimState.CLIMBING,     PlayerAnimStateExecutionMethod.FIXED_TIME }
            };

            private void Start()
            {
                _animator = GetComponent<Animator>();
                _core = MyUtility.Locator<PlayerCore>.GetT();
                //_core.ChangeStateEvent += OnChangeState;
            }

            private void Update()
            {
                switch (_animMethod)
                {
                    case PlayerAnimStateExecutionMethod.PLAY_ONE_SHOT:
                        if (!_playedOneShot)
                        {
                            _animator.Play(_stateHash);
                            _playedOneShot = true;
                        }
                        break;
                    case PlayerAnimStateExecutionMethod.UPDATE:
                        _animator.Play(_stateHash);
                        break;
                    case PlayerAnimStateExecutionMethod.FIXED_TIME:
                        _animator.PlayInFixedTime(_stateHash, 0, _fixedTime);
                        break;
                }
            }

            private void OnChangeState()
            {
                _stateHash = Animator.StringToHash(_state.ToString());
                _animMethod = _animStateMethods[_state];
                _playedOneShot = false;
            }

            public void ChangeFixedTime(float fixedTime)
            {
                _fixedTime += fixedTime;
            }

            public void AddFixedTime(float addTime)
            {
                _fixedTime += addTime;
            }
        }
    }
}
